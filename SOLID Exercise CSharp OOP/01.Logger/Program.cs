using _01.Logger.Appenders.Models;
using _01.Logger.Appenders.Models.Interfaces;
using _01.Logger.Models;
using _01.Logger.Models.Interfaces;

ILayout simpleLayout = new SimpleLayout();
IAppender consoleAppender =
new ConsoleAppender(simpleLayout);
ILogger logger = new Logger(consoleAppender);
logger.Error("Error parsing JSON.");
logger.Info("User Pesho successfully registered.");

