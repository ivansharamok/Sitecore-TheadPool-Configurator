# Sitecore-TheadPool-Configurator
Set ASP.NET application processModel thread limits

## Problem
Certain scenarios require to adjust ASP.NET application pool thread limits. This is typically done on `<processModel>` section in `machine.config` file. However, in certain environments (e.g. Azure WebApp) the `machine.config` may not be available for direct modification.
>**Disclaimer**  
Consider application pool thread limits adjustment as a surgical procedure to address a specific issue that you have confirmed and fully understand its origin. Tempering with application threading mechanism can backfire if you are not entirely sure what issue you are trying to address with it.

## Solution
Use API-based approach to configure ASP.NET application pool thread limits for Sitecore solution.

## Additional resources
[Contention, poor performance, and deadlocks when you make calls to Web services from an ASP.NET application](https://support.microsoft.com/en-in/help/821268/contention-poor-performance-and-deadlocks-when-you-make-calls-to-web-s)