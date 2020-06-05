using Pizza_Palace_Coding_Problem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using Pizza_Palace_Coding_Problem.EF;
using System.Threading.Tasks;
using System.Windows.Input;
using Pizza_Palace_Coding_Problem.EF.Entities;

namespace Pizza_Palace_Coding_Problem.ViewModels
{
    /// <summary>
    /// A business logic for MainWindow. For handling different operations
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {


        PizzaPalaceDbContextFactory _dbContextFactory = new PizzaPalaceDbContextFactory();
        PizzaPalaceDbContext _dbContext;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MainWindowViewModel()
        {
            _dbContext = _dbContextFactory.CreateDbContext(null);
            this.BasicToppings = null;
            this.DeluxeToppings = null;
            FillPizzaInitialData();

        }
        /// <summary>
        /// A funtion to fill initial data(three pizza sizes)
        /// </summary>
        public void FillPizzaInitialData()
        {
            IEnumerable<PizzaSizeModel> pizzaSizes = (from pizzaSize in _dbContext.PizzaSizes
                                                      select new PizzaSizeModel
                                                      {
                                                          Name = pizzaSize.Name,
                                                          Id = pizzaSize.Id
                                                      }).ToList();
            this.PizzaSizes = pizzaSizes;

        }
        /// <summary>
        /// For getting and setting Property values
        /// </summary>
        #region ViewModel Properties
        private IEnumerable<PizzaSizeModel> _pizzaSizes;
        private IEnumerable<ToppingCatalogModel> _basictoppings;
        private IEnumerable<ToppingCatalogModel> _deluxeToppings;
        private IEnumerable<Cart> _cartItems;
        private int _selectedPizzaSize;
        public int SelectedPizzaSize
        {
            get
            {
                return _selectedPizzaSize;
            }
            set
            {
                _selectedPizzaSize = value;
                NotifyPropertyChanged();
            }
        }
        private double _subTotalPrice;
        public double SubTotalPrice
        {
            get
            {
                return Math.Round(_subTotalPrice, 2);
            }
            set
            {
                _subTotalPrice = value;
                NotifyPropertyChanged();
            }
        }
        private double _totalGST;
        public double TotalGST
        {
            get
            {
                return Math.Round(_totalGST, 2);
            }
            set
            {
                _totalGST = value;
                NotifyPropertyChanged();
            }
        }
        private double _totalPrice;
        public double TotalPrice
        {
            get
            {
                return Math.Round(_totalPrice, 2);
            }
            set
            {
                _totalPrice = value;
                NotifyPropertyChanged();
            }
        }
        public IEnumerable<PizzaSizeModel> PizzaSizes
        {
            get
            {
                return _pizzaSizes;
            }
            set
            {
                _pizzaSizes = value;
                NotifyPropertyChanged();
            }
        }

        public IEnumerable<ToppingCatalogModel> BasicToppings
        {
            get
            {
                return _basictoppings;
            }
            set
            {
                _basictoppings = value;
                NotifyPropertyChanged();
            }
        }
        public IEnumerable<ToppingCatalogModel> DeluxeToppings
        {
            get
            {
                return _deluxeToppings;
            }
            set
            {
                _deluxeToppings = value;
                NotifyPropertyChanged();
            }
        }
        public IEnumerable<Cart> CartItems
        {
            get
            {
                return _cartItems;
            }
            set
            {
                _cartItems = value;
                NotifyPropertyChanged();
            }
        }

        #endregion
        public void getToppingsList(int selectedPizzaSize)
        {
            var toppings = (from topping in _dbContext.Toppings
                            join tc in _dbContext.ToppingCategories on topping.ToppingCategoryId equals tc.Id
                            join pz in _dbContext.PizzaSizes on topping.PizzaSizeId equals pz.Id
                            where topping.PizzaSizeId.Equals(selectedPizzaSize)
                            select new ToppingCatalogModel
                            {
                                Name = topping.Name,
                                Id = topping.Id,
                                Price = topping.Price,
                                PizzaSize = topping.PizzaSize,
                                PizzaSizeId = topping.PizzaSizeId,
                                ToppingCategory = topping.ToppingCategory,
                                ToppingCategoryId = topping.ToppingCategoryId

                            })
                            .ToList()
                            .GroupBy(gb => gb.ToppingCategoryId);

            List<ToppingCatalogModel> toppingCatalogs = toppings.SelectMany(group => group).ToList();
            this.BasicToppings = toppingCatalogs.Where(s => s.ToppingCategory.Name == "Basic Toppings").ToList();
            this.DeluxeToppings = toppingCatalogs.Where(s => s.ToppingCategory.Name == "Deluxe Toppings").ToList();

        }
      
        private ICommand _selectPizzaCommand;
        private ICommand _selectPizzaToppingCommand;
        private ICommand _submitCommand;
        /// <summary>
        /// Command for data Binding-Selected Pizza Size
        /// </summary>
        public ICommand SelectPizzaCommand
        {
            get
            {
                return _selectPizzaCommand ?? (_selectPizzaCommand = new CommandHandler((param) => FetchToppingsTask(param), CanExecute()));
            }
        }
        /// <summary>
        /// Command for data Binding Toppings for a Selected Pizza Size
        /// </summary>
        public ICommand SelectPizzaToppingCommand
        {
            get
            {
                return _selectPizzaToppingCommand ?? (_selectPizzaToppingCommand = new CommandHandler((param) => AddToppingsToCartTask(param), CanExecute()));
            }
        }
        /// <summary>
        /// Command for Submit event
        /// </summary>
        public ICommand SubmitCommand
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new CommandHandler((param) => SubmitTask(param), CanExecute()));
            }
        }
        /// <summary>
        /// Allows the control to enable or disable itself based on whether its command can be executed.
        /// </summary>
        private bool CanExecute()
        {
            return true;
        }
        /// <summary>
        /// Handling Selected Topping and addation to temp cart
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private Task FetchToppingsTask(object param)
        {
            this.BasicToppings = null;
            this.DeluxeToppings = null;
            this.SelectedPizzaSize= (int)param;
            getToppingsList((int)param);
            AddPizzaToCartTask((int)param);
            return Task.CompletedTask;
        }
        /// <summary>
        /// Handling Submit Task and persisting data to DB
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private Task SubmitTask(object param)
        {
         
            
            Order order = new Order
            {
                SubTotal= this.SubTotalPrice,
                TaxTotal= this.TotalGST,
                Total= this.TotalPrice,
            };
            using(var context = _dbContextFactory.CreateDbContext(null))
            {
                context.Orders.Add(order);
            context.SaveChanges();
                foreach (var item in CartItems)
                {
                    var orderItem = new OrderItem
                    {
                        UnitPrice = item.Price,
                        ItemId = item.ItemId,
                        OrderId = order.Id,
                        ItemIsATopping= item.ItemIsATopping
                    };
                    context.OrderItems.Add(orderItem);
                    context.SaveChanges();
                }
            }
            return Task.CompletedTask;
        }
        /// <summary>
        /// Handles Adding Toppings To the temp Cart: pass the ToppingsId
        /// Used to update Order Items Datasource for UI binding and Tax Computaion
        /// Sets ItemIsATopping = true,
        /// </summary>
        /// <param name="selectedPizzaTopping"></param>
        /// <returns></returns>
        private Task AddToppingsToCartTask(object selectedPizzaTopping)
        {
            ToppingCatalogModel topping = (from p in _dbContext.Toppings
                                         join tc in _dbContext.ToppingCategories on p.ToppingCategoryId equals tc.Id
                                         join pz in _dbContext.PizzaSizes on p.PizzaSizeId equals pz.Id
                                       where p.Id == (int)selectedPizzaTopping
                                       select new ToppingCatalogModel
                                       {
                                           PizzaSize = p.PizzaSize,
                                           Id = p.Id,
                                           PizzaSizeId = p.PizzaSizeId,
                                           Price = p.Price,
                                           Name=p.Name,
                                           ToppingCategoryId = p.ToppingCategoryId,
                                           ToppingCategory = p.ToppingCategory
                                       }).FirstOrDefault();
            List<Cart> list = CartItems != null ? CartItems.ToList() : new List<Cart>();

            Cart cart = new Cart
            {
                ItemName = string.Format("{0}-{1}", topping.PizzaSize.Name, topping.Name),
                ItemId = topping.Id,
                PizzaSizeId = topping.PizzaSizeId,
                Price = topping.Price,
                ItemIsATopping = true,
            };

            list.Add(cart);
            var price = list.Sum(s => s.Price);
            this.SubTotalPrice = (price * 0.95);
            this.TotalGST = price - SubTotalPrice;
            this.TotalPrice = price;
            CartItems = (IEnumerable<Cart>)list;
            return Task.CompletedTask;
        }
        /// <summary>
        /// Handles Adding Pizza To the temp Cart: pass the PizzaSizeId
        /// Used to update Order Items Datasource for UI binding and Tax Computaion
        /// Sets ItemIsATopping = false,
        /// </summary>
        /// <param name="selectedPizzaTopping"></param>
        /// <returns></returns>
        private void AddPizzaToCartTask(int selectedPizzaSize)
        {
            PizzaCatalogModel pizza = (from p in _dbContext.Pizzas
                                       join pz in _dbContext.PizzaSizes on p.PizzaSizeId equals pz.Id
                                       where p.PizzaSizeId == selectedPizzaSize
                                       select new PizzaCatalogModel
                                       {
                                           PizzaSize = p.PizzaSize,
                                           Id = p.Id,
                                           PizzaSizeId = p.PizzaSizeId,
                                           Price = p.Price,
                                       }).FirstOrDefault();
            List<Cart> list = CartItems != null ? CartItems.ToList() : new List<Cart>();

            Cart cart = new Cart
            {
                ItemName = pizza.PizzaSize.Name,
                ItemId = pizza.Id,
                PizzaSizeId = pizza.PizzaSizeId,
                Price = pizza.Price,
                ItemIsATopping = false
            };

            list.Add(cart);
            var price = Math.Round(list.Sum(s => s.Price), 2);
            this.SubTotalPrice = (price * 0.95);
            this.TotalGST = price - SubTotalPrice;
            this.TotalPrice = price;
            CartItems = (IEnumerable<Cart>)list;
        }
    }
}
