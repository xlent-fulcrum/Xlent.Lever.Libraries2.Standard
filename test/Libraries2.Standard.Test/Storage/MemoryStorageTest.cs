using System;
using System.Threading.Tasks;
using Libraries2.Standard.Test.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xlent.Lever.Libraries2.Standard.Assert;
using Xlent.Lever.Libraries2.Standard.Error.Logic;
using Xlent.Lever.Libraries2.Standard.Storage;
using Xlent.Lever.Libraries2.Standard.Storage.Logic;
using Xlent.Lever.Libraries2.Standard.Storage.Model;
using Xlent.Lever.Libraries2.Standard.Storage.Test;

namespace Libraries2.Standard.Test.Storage
{
    [TestClass]
    public class MemoryStorageTest
    {
        private MemoryStorage<PersonStorableItem<Guid>> _storage;
        private StorageTestCrud<MemoryStorage<PersonStorableItem<Guid>>, PersonStorableItem<Guid>, Guid> _testCrud;

        [TestInitialize]
        public void Inititalize()
        {
            var methodName = $"{typeof(MemoryStorageTest).FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}";
            _storage = new MemoryStorage<PersonStorableItem<Guid>>();
            // ReSharper disable once SuspiciousTypeConversion.Global
            var icrudStorage = _storage as ICrud<IStorableItem<Guid>, Guid>;
            FulcrumAssert.IsNotNull(icrudStorage, $"{methodName}: 6E1C95FD-6245-442F-9D76-FC34E9394672");
            _testCrud = new StorageTestCrud<MemoryStorage<PersonStorableItem<Guid>>, PersonStorableItem<Guid>, Guid>(_storage);
        }

        [TestMethod]
        public async Task TestCrud()
        {
            await _testCrud.RunAllTests();
        }
        
    }
}
