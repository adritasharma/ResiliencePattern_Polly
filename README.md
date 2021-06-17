# ResiliencePattern_Polly

A POC on consuming external Web API with Resilience Pattern (Retry & Circuit Breaker policy)  .NET Core using **Polly**. It is neccesary to make the Microservice resilient.

## Polly

Polly is a .NET resilience and transient-fault-handling library that allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.
We can attach as many policy we want to HttpClientFactory


## Patterns

### Exponential Backoff

It is a technique that retries an operation, with an exponentially increasing wait time, up to a maximum retry count has been reached (the exponential backoff). This technique embraces the fact that cloud resources might intermittently be unavailable for more than a few seconds for some reason.

       private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                // HttpRequestException, 5XX and 408  
                .HandleTransientHttpError()
                // 404  
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                // Retry two times after delay  
                //.WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .WaitAndRetryAsync(2, ComputeDuration, (result, timeSpan, retryCount, context) => {
                    Console.WriteLine($"Retry Count: {retryCount}, Exception: {result.Exception}");
                });
        }


### Circuit Breaker

The Circuit Breaker pattern prevents an application from performing an operation that's likely to fail. An application can combine these two patterns. However, the retry logic should be sensitive to any exception returned by the circuit breaker, and it should abandon retry attempts if the circuit breaker indicates that a fault is not transient.

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            // if 2 consecutive errors occur, the circuit is cut for 30 seconds
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30),(ex, t) =>
                {
                    Console.WriteLine("Circuit broken!");
                },
                () =>
                {
                    Console.WriteLine("Circuit Reset!");
                });
        }

**Example**:

Suppose an application is calling another microservice. The call failures for some reason, the Exponential Backoff pattern allows to retry the call after a wait time with exponentialy increasing the wait time. This handles the situation if the failure was a transient one ( it autofixes after a time period)
Circuit breaker checks if the error is not transient and abandons retry attempts.
