using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace application.experiments;

public class ColosseumExperimentWorker : IHostedService 
{
    private static readonly int DefaultExperimentsNumber = 10_000;
    private readonly IColosseumSandbox _sandbox;
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly ILogger<ColosseumExperimentWorker> _logger;

    public ColosseumExperimentWorker(
        IColosseumSandbox sandbox, 
        IHostApplicationLifetime applicationLifetime,  
        ILogger<ColosseumExperimentWorker> logger)
    {
        _sandbox = sandbox;
        _applicationLifetime = applicationLifetime;
        _logger = logger; 
    }
    
    public void CountStats()
    {
        CountStats(DefaultExperimentsNumber);
    }
    
    public void CountStats(int experimentsNumber)
    {
        int successCounter = 0;
            
        for (int i = 0; i < experimentsNumber; i++)
        {
            if (_sandbox.Action())
            {
                successCounter++;
            }
        }
        double stats = ((double)successCounter / experimentsNumber) * 100;
        
        // _logger.LogInformation($"Number of experiments: {experimentsNumber}");
        // _logger.LogInformation($"Success rate: {stats}%");
        Console.WriteLine($"Number of experiments: {experimentsNumber}");
        Console.WriteLine($"Success rate: {stats}%");
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("MyService is starting.");

        CountStats();
        
        _applicationLifetime.StopApplication();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("MyService is stopping.");

        return Task.CompletedTask;
    } 
}