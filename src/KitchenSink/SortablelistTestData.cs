using Starcounter;

namespace KitchenSink
{
    static class SortablelistTestData
    {
        static public bool Exists()
        {
            var result = Db.SQL<People>("SELECT e FROM People e fetch ?",1).First;
            if (result != null)
            {
                return true;
            }

            return false;
        }
        static public void Create()
        {
            Db.Transact(() =>
            {
                var Elias = new People() { Counter = 1, Firstname = "Elias", Lastname = "Aarflot"};
                var Bo = new People() { Counter = 2, Firstname = "Bo", Lastname = "Foo"};
                var Li = new People() { Counter = 3, Firstname = "Li", Lastname = "Bar"};
                var Ann = new People() { Counter = 4, Firstname = "Ann", Lastname = "Hello"};

            });

        }
    }
}
