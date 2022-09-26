using System.Collections.Generic;
using MonoController.Interfaces;

namespace MonoController
{
    public class Controllers
    {
        private readonly List<IAwake> _awakes;
        private readonly List<IStart> _starts;
        private readonly List<IEnable> _enables;
        private readonly List<IUpdate> _updates;
        private readonly List<IFixedUpdate> _fixedUpdates;
        private readonly List<ILateUpdate> _lateUpdates;
        private readonly List<IDisable> _disables;
        private readonly List<IDestroy> _destroys;

        public Controllers()
        {
            _awakes = new List<IAwake>();
            _starts = new List<IStart>();
            _enables = new List<IEnable>();
            _updates = new List<IUpdate>();
            _fixedUpdates = new List<IFixedUpdate>();
            _lateUpdates = new List<ILateUpdate>();
            _disables = new List<IDisable>();
            _destroys = new List<IDestroy>();
        }
        
        public void AddController(IController controller)
        {
            if (controller is IAwake awake)
            {
                _awakes.Add(awake);
            }
            
            if (controller is IStart start)
            {
                _starts.Add(start);
            }
            
            if (controller is IEnable enable)
            {
                _enables.Add(enable);
            }
            
            if (controller is IUpdate update)
            {
                _updates.Add(update);
            }
            
            if (controller is IFixedUpdate fixedUpdate)
            {
                _fixedUpdates.Add(fixedUpdate);
            }
            
            if (controller is ILateUpdate lateUpdate)
            {
                _lateUpdates.Add(lateUpdate);
            }
            
            if (controller is IDisable disable)
            {
                _disables.Add(disable);
            }
            
            if (controller is IDestroy destroy)
            {
                _destroys.Add(destroy);
            }
        }

        public void RemoveController(IController controller)
        {
            if (controller is IAwake awake)
                _awakes.Remove(awake);
            
            if (controller is IStart start)
                _starts.Remove(start);
            
            if (controller is IEnable enable)
                _enables.Remove(enable);
            
            if (controller is IUpdate update)
                _updates.Remove(update);
            
            if (controller is IFixedUpdate fixedUpdate)
                _fixedUpdates.Remove(fixedUpdate);
            
            if (controller is ILateUpdate lateUpdate)
                _lateUpdates.Remove(lateUpdate);
            
            if (controller is IDisable disable)
                _disables.Remove(disable);
            
            if (controller is IDestroy destroy) 
                _destroys.Remove(destroy);
        }

        public void Awakes()
        {
            _awakes.ForEach(awake => awake.Awake());
        }

        public void Starts()
        {
            _starts.ForEach(start => start.Start());
        }

        public void OnEnables()
        {
            _enables.ForEach(enable => enable.OnEnable());
        }

        public void Updates(float deltaTime)
        {
            _updates.ForEach(update => update.Update(deltaTime));
        }

        public void FixedUpdates(float fixedDeltaTime)
        {
            _fixedUpdates.ForEach(fixedUpdate => fixedUpdate.FixedUpdate(fixedDeltaTime));
        }

        public void LateUpdates()
        {
            _lateUpdates.ForEach(lateUpdate => lateUpdate.LateUpdate());
        }
        
        public void OnDisables()
        {
            _disables.ForEach(disable => disable.OnDisable());
        }

        public void OnDestroys()
        {
            _destroys.ForEach(destroy => destroy.OnDestroy());
        }
    }
}