
namespace Orders_CRUD
{
    public class RequestHandler
    {
        public static List<string> getOrderItemUnits()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<string> orderUnits = new List<string>();
                var dbOrderUnits = db.OrderItems.GroupBy(p => p.Unit).Select(p => p.First()).ToList();
                foreach (var order in dbOrderUnits)
                {
                    orderUnits.Add(order.Unit);
                }
                return orderUnits;
            }
        }
        public static List<string> getOrderItemNames()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<string> orderNames = new List<string>();
                var dbOrderNames = db.OrderItems.GroupBy(p => p.Name).Select(p => p.First()).ToList();
                foreach (var order in dbOrderNames)
                {
                    orderNames.Add(order.Name);
                }
                return orderNames;
            }
        }
        public static List<string> getProvidersNames()
        {
            using (ApplicationContext db  = new ApplicationContext ())
            {
                List<string> providers = new List<string>();
                var dbProviders = db.Providers.GroupBy(p => p.Name).Select(p => p.First()).ToList();
                foreach ( var provider in dbProviders )
                {
                    providers.Add(provider.Name);
                }
                return providers;
            }
        }
        public static List<OrderViewModel> getInfoForAllOrders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var all_orders = from order in db.Orders
                                 join orderItem in db.OrderItems on order.Id equals orderItem.OrderId
                                 join provider in db.Providers on order.ProviderId equals provider.Id
                                 select new
                                 {
                                     OrderNumber = order.Number,
                                     OrderCreateDate = order.Date,
                                     ProviderName = provider.Name,
                                     OrderItemName = orderItem.Name,
                                     OrderItemQuantity = orderItem.Quantity,
                                     OrderItemUnit = orderItem.Unit
                                 };

                List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
                int i = 0;
                foreach(var order in all_orders)
                {
                    var orderViewModel = new OrderViewModel()
                    {
                        Id = i,
                        OrderCreateDate = order.OrderCreateDate,
                        OrderItemName = order.OrderItemName,
                        OrderItemQuantity = order.OrderItemQuantity,
                        OrderItemUnit = order.OrderItemUnit,
                        OrderNumber = order.OrderNumber,
                        ProviderName = order.ProviderName
                    };
                    orderViewModels.Add(orderViewModel);
                    i++;
                }
                return orderViewModels;
            }
        }
    }
}
