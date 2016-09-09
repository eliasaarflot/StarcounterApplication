using Starcounter;
using System;
using System.Collections.Generic;

namespace KitchenSink
{
    partial class SortablelistPage : Json
    {
        public void Init()
        {
            if (!SortablelistTestData.Exists())
            {
                SortablelistTestData.Create();
            }
            var query = Db.SQL<People>("SELECT e FROM People e ORDER BY Counter");

            People.Data = query;


        }
        //QueryResultRows<global::People> all


        [SortablelistPage_json.People]
        partial class SortablelistPersonItem : Json, IBound<People>
        {
            public void Handle(Input.MoveUp Action)
            {
                var trader = Counter;
                var tradeTo = trader - 1;

                var personToTrade = Db.SQL<People>("SELECT e FROM People e WHERE Counter = ? ", trader).First;
                var personToTradeWith = Db.SQL<People>("SELECT e FROM People e WHERE Counter = ?", tradeTo).First;
                var all = Db.SQL<People>("SELECT e FROM People e");

                if (personToTradeWith != null)
                {
                    var firstnameFirst = personToTrade.Firstname;
                    var lastnameFirst = personToTrade.Lastname;
                    var firstnameSecond = personToTradeWith.Firstname;
                    var lastnameSecond = personToTradeWith.Lastname;


                    foreach (var p in all)
                    {
                        if (p.Counter == personToTradeWith.Counter)
                        {
                            Db.Transact(() =>
                            {
                                p.Firstname = firstnameFirst;
                                p.Lastname = lastnameFirst;
                            });

                        }
                        if (p.Counter == personToTrade.Counter)
                        {
                            Db.Transact(() =>
                            {
                                p.Firstname = firstnameSecond;
                                p.Lastname = lastnameSecond;
                            });

                        }
                    }
                    Transaction.Commit();
                }
                //var query = Db.SQL<People>("SELECT e FROM People e");

                //foreach (People p in query)
                //{
                //    Db.Transact(() =>
                //    {
                //         = 0;
                //    });

                //}
                //int listCounter = 0;
                //foreach (People p in query)
                //{
                //    Db.Transact(() =>
                //    {
                //        Id = listCounter;
                //    });
                //    listCounter++;
                //}
                //Transaction.Commit();
                ////var queryTwo = Db.SQL<People>("SELECT e FROM People e fetch ?", );

                ////var result = Db.SQL<People>("SELECT e FROM People e fetch ?", this.GetObjectNo()).First;




                //var person = Db.SQL<People>("SELECT p FROM People p WHERE p.ObjectNo = ?", this.Data.GetObjectNo()).First;

                //ulong personAboveCalc = this.Data.GetObjectNo() - 1;
                //var personAbove = Db.SQL<People>("SELECT p FROM People p WHERE p.ObjectNo = ?", personAboveCalc).First;


                //if (personAbove != null)
                //{
                //    Db.Transact(() =>
                //    {
                //        person = personAbove;
                //        personAbove = person;
                //    });

                //}
                //Transaction.Commit();


            }
            public void Handle(Input.MoveDown Action)
            {
                //var query = Db.SQL<People>("SELECT e FROM People e");

                //int listCounter = 1;

                //foreach (People p in query)
                //{
                //    Db.Transact(() =>
                //    {
                //        p.Counter = listCounter;
                //    });


                //    listCounter++;
                //}
                //Transaction.Commit();

                var trader = Counter;
                var tradeTo = trader + 1;

                var personToTrade = Db.SQL<People>("SELECT e FROM People e WHERE Counter = ? ", trader).First;
                var personToTradeWith = Db.SQL<People>("SELECT e FROM People e WHERE Counter = ?", tradeTo).First;
                var all = Db.SQL<People>("SELECT e FROM People e");

                if (personToTradeWith != null)
                {
                var firstnameFirst = personToTrade.Firstname;
                var lastnameFirst = personToTrade.Lastname;
                var firstnameSecond = personToTradeWith.Firstname;
                var lastnameSecond = personToTradeWith.Lastname;


                    foreach (var p in all)
                    {
                        if (p.Counter == personToTradeWith.Counter)
                        {
                            Db.Transact(() =>
                            {
                                p.Firstname = firstnameFirst;
                                p.Lastname = lastnameFirst;
                            });

                        }
                        if (p.Counter == personToTrade.Counter)
                        {
                            Db.Transact(() =>
                            {
                                p.Firstname = firstnameSecond;
                                p.Lastname = lastnameSecond;
                            });

                        }
                    }
                    Transaction.Commit();
                }


            }
        }


    }
}
