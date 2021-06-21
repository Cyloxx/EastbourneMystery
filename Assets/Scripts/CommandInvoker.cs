using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EastBourne
{
    public class CommandInvoker : MonoBehaviour
    {

        static Queue<ICommand> commandBuffer;
        public List<Queue> lookUpList;

        private void Awake()
        {
            commandBuffer = new Queue<ICommand>();
        }

        public static void AddCommand(ICommand command)
        {
            commandBuffer.Enqueue(command);
        }

        // Update is called once per frame
        void Update()
        {
            if (commandBuffer.Count > 0)
            {
                ICommand c = commandBuffer.Dequeue();
                c.JumpExecute();
                // commandBuffer.Dequeue().Movement();
            }
        }

        //MEMENTO Pattern
    } 
}
