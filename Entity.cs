using System;
using System.Collections.Generic;
using System.Text;

namespace _2020GameJam
{
    class Entity
    {
        public string _name;
        public float _health;
        public int _damage;

        public Entity()
        {
            _name = "Player";
            _health = 100;
            _damage = 3;
        }

        public Entity(string nameVal, float healthVal, int damageVal)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
        }

        public float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if(_health < 0)
            {
                _health = 0;
            }

            return damageVal;
        }

        public float Attack(Entity enemy)
        {
            float damageTaken = enemy.TakeDamage(_damage);
            return damageTaken;
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public bool GetIsNotAlive()
        {
            return _health < 1;
        }
    }
}
