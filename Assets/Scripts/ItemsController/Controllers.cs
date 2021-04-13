using UnityEngine;
using System.Collections.Generic;

namespace Items
{
    public class Controllers : IInit, IUpdate, ILateUpdate, IClean
    {
        private readonly List<IInit> _initControllers;
        private readonly List<IUpdate> _updateControllers;
        private readonly List<ILateUpdate> _lateControllers;
        private readonly List<IClean> _cleanControllers;
        
       
           
            
        

        internal Controllers()
        {
            _initControllers = new List<IInit>();
            _updateControllers = new List<IUpdate>();
            _lateControllers = new List<ILateUpdate>();
            _cleanControllers = new List<IClean>(); 
            
        }
        
        internal Controllers Add(IController controller)
        {
            if (controller is IInit initController)
            {
                _initControllers.Add(initController);
            }

            if (controller is IUpdate updateController)
            {
                _updateControllers.Add(updateController);
            }

            if (controller is ILateUpdate lateUpdateController)
            {
                _lateControllers.Add(lateUpdateController);
            }
            
            if (controller is IClean cleanController)
            {
                _cleanControllers.Add(cleanController);
            }

            return this;
        }
        
        public void Initialization()
        {
            foreach (var element in _initControllers)
            {
                element.Initialization();
            }
        }
        
        public void Execute(float deltaTime)
        {
            foreach (var element in _updateControllers)
            {
                element.Execute(deltaTime);
            }
        }
        
        public void LateExecute(float deltaTime)
        {
            foreach (var element in _lateControllers)
            {
                element.LateExecute(deltaTime);
            }
        }

        public void Clean()
        {
            foreach (var element in _cleanControllers)
            {
                element.Clean();
            }
        }
    }
}