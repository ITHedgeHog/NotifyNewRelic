using CommandLine;
using CommandLine.Text;

namespace ITHedgeHog.Notifier
{
    internal class Options
    {
        [Option('a', "appid", Required = true, HelpText = "Application Id")]
        public string AppId { get; set; }
        [Option('d', "Description", Required = true, HelpText = "")]
        public string Description { get; set; }
        [Option('r', "revision", Required = false, HelpText = "Software Revision")]
        public string Revision { get; set; }
        [Option('c', "ChangeLog", Required = false)]
        public string ChangeLog { get; set; }
        [Option('u', "user", Required = true)]
        public string User { get; set; }
        [Option('n', "AppName", Required = true)]
        public string AppName { get; set; }
        [Option('k', "apikey", Required = true)]
        public string ApiKey { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
