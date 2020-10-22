﻿using System;
using System.ComponentModel;
using FluentAssertions;

// ReSharper disable UnusedMember.Global
namespace Wild.TestHelpers.Extensions
{
    public class NotifyExpectation<T>
        where T : INotifyPropertyChanged
    {
        private readonly T _owner;
        private readonly string _propertyName;
        private readonly bool _eventExpected;

        public NotifyExpectation(T owner, string propertyName, bool eventExpected)
        {
            _owner = owner;
            _propertyName = propertyName;
            _eventExpected = eventExpected;
        }

        public void When(Action<T> action)
        {
            var eventWasRaised = false;
            _owner.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == _propertyName)
                {
                    eventWasRaised = true;
                }
            };

            action(_owner);

            eventWasRaised
                .Should()
                .Be(_eventExpected,
                    $"PropertyChanged on {_propertyName}");
        }
    }
}
