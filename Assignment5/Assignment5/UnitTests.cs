using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class UnitTests
    {
        Inventory inventory;
        Character hero;


        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory(5);
            hero = new Character("Cloud", RaceCategory.Human, 120);
        }

        [TearDown]
        public void CleanUp()
        {
            inventory = null;
            hero = null;
        }

        [TestCase(70)]
        public void ReduceTheCorrectAmountOfHealth(int expectedValue)
        {
            hero.TakeDamage(50);
            Assert.IsTrue(hero.Health == expectedValue);
        }

        [Test]
        public void CheckIfPlayerIsAliveAfterTooMuchDamage()
        {
            hero.TakeDamage(130);
            Assert.IsTrue(hero.IsAlive == false);
        }

        [TestCase(50)]
        public void HealTheCorrectAmount(int amount)
        {
            hero.TakeDamage(50);
            hero.RestoreHealth(amount);
            Assert.IsTrue(hero.Health == 120);
        }

        [Test]
        public void CheckIfPlayerIsAliveAfterHealing()
        {
            hero.TakeDamage(130);
            hero.RestoreHealth(10);
            Assert.IsTrue(hero.IsAlive == true);
        }

        [Test]
        public void RemoveItemTrueAndCheckIfAvailableSlotsIncrease()
        {
            
            inventory.AddItem(new Item("Sword", 1, ItemGroup.Equipment));
            int value = inventory.AvailableSlots;
            Assert.IsTrue(inventory.TakeItem("Sword", out Item item));
            Assert.IsTrue(inventory.AvailableSlots > value);
        }

        [Test]
        public void RemoveItemFalseAvailableSlotsRemainSame()
        {
            inventory.AddItem(new Item("Potion", 1, ItemGroup.Consumable));
            int value = inventory.AvailableSlots;
            Assert.IsFalse(inventory.TakeItem(" ", out Item item));
            Assert.IsTrue(inventory.AvailableSlots == value);
        }

        [Test]
        public void AddItemAndCheckIfExists()
        {
            int value = inventory.AvailableSlots;
            inventory.AddItem(new Item("Phoenix Down", 1, ItemGroup.Consumable));
            Assert.IsTrue(value > inventory.AvailableSlots);
            Assert.IsTrue(inventory.ListAllItems().Exists(x => x.Name == "Phoenix Down"));
        }

        [Test]
        public void ResetInventory()
        {
            inventory.Reset();
            Assert.IsTrue(inventory.AvailableSlots == inventory.MaxSlots);
            Assert.IsTrue(inventory.ListAllItems().Count == 0);
        }

    }
}
