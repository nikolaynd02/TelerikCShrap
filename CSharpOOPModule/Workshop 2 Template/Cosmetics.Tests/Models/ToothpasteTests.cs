﻿using Cosmetics.Models;
using Cosmetics.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using static Cosmetics.Tests.Helpers.TestData;

namespace Cosmetics.Tests.Models
{
    [TestClass]
    public class ToothpasteTests
    {
        [TestMethod]
        public void Constructor_Should_ThrowException_When_NameLengthOutOfBounds()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Toothpaste(
                    name: ToothpasteData.InvalidName,
                    brand: ToothpasteData.ValidBrand,
                    price: 10m,
                    gender: GenderType.Men,
                    ingredients: "ingredient1,ingredient2"));
        }

        [TestMethod]
        public void Constructor_Should_ThrowException_When_BrandLengthOutOfBounds()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new Toothpaste(
                    name: ToothpasteData.ValidName,
                    brand: ToothpasteData.InvalidBrand,
                    price: 10m,
                    gender: GenderType.Women,
                    ingredients: "ingredient1,ingredient2"));
        }

        [TestMethod]
        public void Constructor_Should_ThrowException_When_PriceIsNegative()
        {
			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
				new Toothpaste(
					name: ToothpasteData.ValidName,
					brand: ToothpasteData.ValidBrand,
					price: -1m,
					gender: GenderType.Men,
					ingredients: "ingredient1,ingredient2"));
		}

        [TestMethod]
        public void Constructor_Should_ThrowException_When_IngredientsAreNull()
        {
			Assert.ThrowsException<ArgumentNullException>(() =>
				new Toothpaste(
					name: ToothpasteData.ValidName,
					brand: ToothpasteData.ValidBrand,
					price: 10m,
					gender: GenderType.Unisex,
					ingredients: null));
		}

        [TestMethod]
        public void Constructor_Should_CreateToothpaste_When_ValidValuesArePassed()
        {
			var toothpaste = new Toothpaste(
				name: ToothpasteData.ValidName,
				brand: ToothpasteData.ValidBrand,
				price: 10m,
				gender: GenderType.Women,
				ingredients: "ingredient1,ingredient2");

			Assert.IsInstanceOfType(toothpaste, typeof(Toothpaste));
		}
    }
}
