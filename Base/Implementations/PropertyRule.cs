﻿using Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Implementations
{
    public class PropertyRule : IPropertyRule
    {
        private List<IRule> _rules = new List<IRule>();
        private List<string> _errors;
        private Base.Enumerations.ErrorLevel _errorLevel;
        public IEnumerable<string> Errors
        {
            get
            {
                return _errors;
            }
        }

        public List<IRule> Rules
        {
            get
            {
                return _rules;
            }
        }
        public Base.Enumerations.ErrorLevel ErrorLevel
        {
            get
            {
                return _errorLevel;
            }
        }
        public PropertyRule(List<IRule> rules)
        {
            if (rules != null)
            {
                _rules = rules;
            }
        }
        public PropertyRule(IRule rule)
        {
            _rules.Add(rule);
        }
        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
        }
        public void Update()
        {
            _errors = new List<string>();
            _errorLevel = Base.Enumerations.ErrorLevel.Unassigned;
            try
            {
                foreach (IRule r in _rules)
                {
                    if (!r.Expression())
                    {
                        _errors.Add(r.Message);
                        if (_errorLevel > Base.Enumerations.ErrorLevel.Unassigned)
                        {
                            _errorLevel = _errorLevel | r.ErrorLevel;
                        }
                        else
                        {
                            _errorLevel = r.ErrorLevel;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                _errors.Add(e.Message);
                _errorLevel = Base.Enumerations.ErrorLevel.Fatal;
            }
        }

    }
}