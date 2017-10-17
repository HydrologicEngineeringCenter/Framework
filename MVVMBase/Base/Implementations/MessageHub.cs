﻿using System.Collections.Generic;
using Base.Events;

namespace Base.Implementations
{
    public sealed class MessageHub : Base.Interfaces.IReportMessage
    {
        public event MessageReportedEventHandler MessageReport;
        private static List<Base.Interfaces.IRecieveMessages> _subscribers;
        public void ReportMessage(object sender, MessageEventArgs e)
        {
            MessageReport?.Invoke(sender, e);
        }
        public static readonly MessageHub Instance = new MessageHub();
        private MessageHub()
        {
            _subscribers = new List<Base.Interfaces.IRecieveMessages>();
        }
        public static void Subscribe(Base.Interfaces.IRecieveMessages listener)
        {
            _subscribers.Add(listener);
        }
        public static void Register(Base.Interfaces.IReportMessage messanger)
        {
            messanger.MessageReport += Broadcast;
        }
        public static void Unregister(Base.Interfaces.IReportMessage messanger)
        {
            messanger.MessageReport -= Broadcast;
        }
        private static void Broadcast(object sender, MessageEventArgs e)
        {
            foreach (Base.Interfaces.IRecieveMessages s in _subscribers)
            {
                
                if (s.SenderTypeFilter == null)
                {
                    if (s.MessageTypeFilter == null)
                    {
                        //error filter?
                        s.RecieveMessage(sender, e);
                    } else if (s.MessageTypeFilter == e.GetType())
                    {
                        //error filter?
                        s.RecieveMessage(sender, e);
                    }
                }else if(s.SenderTypeFilter == sender.GetType())
                {
                    if (s.MessageTypeFilter == null)
                    {
                        //error filter?
                        s.RecieveMessage(sender, e);
                    }
                    else if (s.MessageTypeFilter == e.GetType())
                    {
                        //error filter?
                        s.RecieveMessage(sender, e);
                    }
                }
            }
        }
        public static void UnsubscribeAll(Base.Interfaces.IRecieveMessages listener)
        {
            foreach (Base.Interfaces.IRecieveMessages s in _subscribers)
            {
                if (s == listener) _subscribers.Remove(s);
            }
        }
        public static void Unsubscribe(Base.Interfaces.IRecieveMessages listener, Base.Enumerations.ErrorLevel filterLevel, System.Type filterType)
        {
            foreach (Base.Interfaces.IRecieveMessages s in _subscribers)
            {
                if (s == listener) _subscribers.Remove(s);
            }
        }
    }
}
