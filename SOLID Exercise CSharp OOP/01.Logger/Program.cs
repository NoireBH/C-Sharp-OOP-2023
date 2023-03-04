using _01.Logger.Appenders.Models;
using _01.Logger.Appenders.Models.Interfaces;
using _01.Logger.Enums;
using _01.Logger.Models;
using _01.Logger.Models.Interfaces;
using _01.Logger.Models.Layouts;

var simpleLayout = new SimpleLayout();
var logfile = new LogFile();
var consoleAppender = new ConsoleAppender(simpleLayout,logfile);
var fileappender = new FileAppender(simpleLayout, logfile);
consoleAppender.ReportLevel = ReportLevel.Error;
fileappender.ReportLevel = ReportLevel.Error;

var logger = new Logger(consoleAppender,fileappender);

logger.Info("Everything seems fine");
logger.Warning("Warning: ping is too high - disconnect imminent");
logger.Error("Error parsing request");
logger.Critical("No connection string found in App.config");
logger.Fatal("mscorlib.dll does not respond");



