using System;
using System.Linq;
using Missive.Configuration;
using Should;

namespace Tests.Configuration.converters
{
    public class default_untyped : configuration_context
    {
        public default_untyped()
        {
            given_config(new MissiveConfiguration().Converter(typeof(TricorderConverter)));
        }

        public void converter_type_set()
        {
            configuration.ConfigurationModel.Converters.Single().ShouldEqual(typeof (TricorderConverter));
        }
    }

    public class incorrect_untyped : configuration_context
    {
        public incorrect_untyped()
        {
            given_config(()=> new MissiveConfiguration().Converter(typeof (Potato)));
        }

        public void error_is_raised()
        {
            error.ShouldBeType<InvalidOperationException>();
        }
    }

}