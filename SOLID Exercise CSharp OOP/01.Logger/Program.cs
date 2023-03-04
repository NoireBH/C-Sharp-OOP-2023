using _01.Logger.Appenders.Models;
using _01.Logger.Appenders.Models.Interfaces;
using _01.Logger.Models;
using _01.Logger.Models.Interfaces;
using _01.Logger.Models.Layouts;

var simpleLayout = new XmlLayout();
var logfile = new LogFile();
var consoleAppender = new ConsoleAppender(simpleLayout,logfile);

var file = new LogFile();
var fileAppender = new FileAppender(simpleLayout, file);

var logger = new Logger(consoleAppender, fileAppender);
logger.Error("Error parsing JSON.");
logger.Info("User Pesho successfully registered.");


