using System;
using System.Collections.Generic;

namespace Liftoff.Daemon.CommandLine {

    public class CommandLineElements {

        public string Verb { get; }
        public IDictionary<String,String> Options { get; }
        public ISet<String> Switches { get; }

        public CommandLineElements(string verb, IDictionary<String,String> options, IEnumerable<String> switches) {
            Verb = verb;
            Options = new Dictionary<String,String>(options);
            Switches = new HashSet<String>(switches);
        }
    }

    internal static class CommandLineParser {

        public class CommandLineException : ApplicationException {
            public CommandLineException(string message) : base(message) {
            }
        } 

        public static CommandLineElements Parse(string[] args) {

            string verb = "run";
            var options = new Dictionary<String,String>();
            var switches = new HashSet<String>();

            // TODO: first argument needs to be discarded
            // TODO: fix cmd line args in launch.json
            // TODO: remove .vscode folder from src folder

            if (args.Length != 0) {

                var argQueue = new Queue<String>(args);

                verb = argQueue.Dequeue().ToLower();

                while (argQueue.Count > 0) {

                    string arg = argQueue.Dequeue();
                    
                    if (arg.StartsWith("--")) {
                        switches.Add(arg.Substring(2).ToLower());
                    } else if (arg.StartsWith("-")) {

                        string optionText = arg.Substring(1);

                        if (optionText.Contains(":")) {

                            string[] optionKeyValue = optionText.Split(':');

                            if (optionKeyValue.Length < 2) {
                                throw new CommandLineException($"Malformed option in argument: {arg}");
                            }

                            string key = optionKeyValue[0];
                            string value = optionKeyValue[1];

                            options[key] = value;

                        } else {

                            string key = optionText;
                            string value = argQueue.Dequeue();

                            options[key] = value;
                        }
                    }
                }
            }

            return new CommandLineElements(verb, options, switches);
        }
    }
}
