using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace LitCodeOloloNadOther
{
    /// <summary>
    /// shit naming - my shit project - my shit rules - thsi class maked 
    /// for multi threading and syncronizing of someshit and testing this
    /// </summary>
    public class MegaExample
    {
        private LockableObj MyObj = new();
        static long counter = 0;

        // concurrent structures no testing - i use it always

        #region interlocked
        public void  DoInterlocked()//add return 2000000 in tests
        {

            Thread thread1 = new Thread(() => JustDoItInreLoccked());
            Thread thread2 = new Thread(() => JustDoItInreLoccked());

            thread1.Start(); thread2.Start();
            thread1.Join(); thread2.Join();

            Console.WriteLine("Counter value is {0}", counter); // Counter гарантированно будет равен 2000000

        }


        private  void JustDoItInreLocckedFail()
        {
            for (long i = 0; i < 1000000; i++)
                 counter++;
        }

        private void JustDoItInreLoccked()
        {
            for (long i = 0; i < 1000000; i++)
                Interlocked.Increment(ref counter);
        }

        #endregion


        public void EasyMonitor()
        {
            Thread thread1 = new Thread(() => JustMonitorsTrying());
            Thread thread2 = new Thread(() => JustMonitorsTrying());

        }

        private void JustMonitorsTrying()
        {

            //if (Monitor.TryEnter(MyObj, TimeSpan.FromSeconds(5)))
            //{ ... }
            //else
            //{
            //    Console.WriteLine("Монитор заблокирован");
            //}

            Monitor.Enter(MyObj);
            try
            {
                MyObj.incrementList();
            }
            finally
            {
                Monitor.Exit(MyObj);
            }

            //var syncObj = MyObj;

            //// один поток ждет события
            //Monitor.Enter(syncObj);
            //Monitor.Wait(syncObj);
            //Console.WriteLine("Поток проснулся!");
            //Monitor.Exit(syncObj);

            //// другой поток уведомляет первый
            //Monitor.Enter(syncObj);
            //Monitor.Pulse(syncObj);
            //Monitor.Exit(syncObj);


        }




    }





    internal class LockableObj
    {

        public List<int> ints = new List<int>();
       




        internal LockableObj()
        {
            for(int i = 0; i < 10; i++) 
                ints.Add(0);

        }



        internal void incrementList() 
        {
            for(int i = 0;i < 10; i++)
            {
                ints[i]++;
            }
        }
    }

    /// <summary>
    /// i need to make test for it
    /// </summary>
    public class VolatileExample
    {
        volatile bool flag = false;

        public void SetFlag()
        {
            flag = true;
        }

        public bool GetFlag()
        {
            return flag;
        }
    }


}
