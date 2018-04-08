# Sitecore-TheadPool-Configurator
Set ASP.NET application processModel thread limits

[![Build status](https://ivansharamok.visualstudio.com/_apis/public/build/definitions/2ec1bc18-0293-4723-aa8d-fe71ef469a07/2/badge)](https://ivansharamok.visualstudio.com/SitecoreProjects/_build/index?definitionId=2)
[![Total downloads](https://img.shields.io/github/downloads/ivansharamok/Sitecore-TheadPool-Configurator/total.svg)](https://github.com/ivansharamok/Sitecore-TheadPool-Configurator/releases)


## Problem
Certain scenarios require to adjust ASP.NET application pool thread limits. This is typically done on `<processModel>` section in `machine.config` file. However, in certain environments (e.g. Azure WebApp) the `machine.config` may not be available for direct modification.
>**Disclaimer**  
Consider application pool thread limits adjustment as a surgical procedure to address a specific issue that you have confirmed and fully understand its origin. Tempering with application threading mechanism can backfire if you are not entirely sure what issue you are trying to address with it.

## Solution
Use API-based approach to configure ASP.NET application pool thread limits for Sitecore solution.

## Version relevancy
This solution was developed and tested with Sitecore 8.2 version.  
In Sitecore 9 a new processor was introduced `/sitecore/pipelines/initialize/processor[@type="type='Sitecore.Analytics.Pipelines.Loader.StartThreadPoolSizeMonitor, Sitecore.Analytics'"]` to make application adjust its thread limits dynamically based on available threads.

## Additional resources
* [Tune Sitecore CD role for experience data collection](http://blog.sharamok.com/2018-04-07/prepare-cd-for-experience-data-collection/)
* [Contention, poor performance, and deadlocks when you make calls to Web services from an ASP.NET application](https://support.microsoft.com/en-in/help/821268/contention-poor-performance-and-deadlocks-when-you-make-calls-to-web-s)
* [ASP.NET 2.0 Performance Guidelines - Threading](http://www.guidanceshare.com/wiki/ASP.NET_2.0_Performance_Guidelines_-_Threading)

## Credits
Kudos to [Nick Mitikov](https://github.com/mitikov) for the idea and sample code.