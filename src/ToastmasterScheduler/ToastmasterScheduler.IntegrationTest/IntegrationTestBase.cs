using System;
using Raven.Client;
using Raven.Client.Document;

namespace ToastmasterScheduler.IntegrationTest
{
    public abstract class IntegrationTestBase
    {
        private static readonly Lazy<IDocumentStore> Lazy = new Lazy<IDocumentStore>(() => new DocumentStore()
        {
            ConnectionStringName = "RavenDB"
        }.Initialize());

        public static IDocumentStore DocumentStore { get { return Lazy.Value; } } 
    }
}
