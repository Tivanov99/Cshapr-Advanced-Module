using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy
{
    public class FakeDummy : ITarget
    {
        public int Health => 0;

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
