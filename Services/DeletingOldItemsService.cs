using FirstSide.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FirstSide.Services
{
    public class DeletingOldItemsService : IHostedService, IDisposable
    {
        private readonly ILogger<DeletingOldItemsService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer _timer;
        public DeletingOldItemsService(ILogger<DeletingOldItemsService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed hosted service running");
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
               TimeSpan.FromHours(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var events = appDbContext.EventRestaurants.Where(s => s.DateEnd.Date <= DateTime.Now);
                var eventsClubs = appDbContext.EventClubs.Where(s => s.DateEnd.Date <= DateTime.Now);
                if (events.Count()>0 || eventsClubs.Count()>0 )
                {
                    appDbContext.EventRestaurants.RemoveRange(events);
                    appDbContext.EventClubs.RemoveRange(eventsClubs);
                    appDbContext.SaveChanges();
                    _logger.LogInformation("Items is deleting");
                }
                else
                {
                    _logger.LogInformation("Items is null");
                }
            }

        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
