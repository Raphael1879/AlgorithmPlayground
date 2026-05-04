using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePathFind.Snake.Models
{
    public class LastKeyPressedListener
    {


        public ConsoleKey? LastPressedKey { get; set; }

        private bool _listening = false;
        private Thread? _threadRef;


        public void StartListening()
        {
            if (_listening) return;

            _listening = true;


            _threadRef = new Thread(ListenLoop)
            {
                IsBackground = true,
            };

            _threadRef.Start();
        }


        public void StopListening() { 
        
            if(!_listening) return;

            _listening = false;
            _threadRef = null;
        }

        private void ListenLoop()
        {
            while (_listening)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    LastPressedKey = key;
                }

                Thread.Sleep(1); // prevents CPU spin
            }
        }
    }
}
