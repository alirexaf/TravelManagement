﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Domain.Exceptions;

namespace TravelManagement.Domain.ValueObjects
{
    public record TravelerCheckListName
    {
        public string Value { get; }
        public TravelerCheckListName(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new TravelerCheckListNameException();

            Value = value.Trim();
        }
        public static implicit operator string(TravelerCheckListName name)
            => name.Value;
        public static implicit operator TravelerCheckListName(string name)
            => new(name);
    }
}
