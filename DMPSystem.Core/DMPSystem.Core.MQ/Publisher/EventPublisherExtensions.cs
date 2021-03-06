﻿using System;
using System.Collections.Generic;
using DMPSystem.Core.EventBus.EventModel;
using DMPSystem.Core.EventBus.Rabbit;

namespace DMPSystem.Core.EventBus.Publisher
{
    public static class EventPublisherExtensions
    {
        #region 同步通知
        public static void EntityInserted<T>(this IEventPublisher eventPublisher, T entity) where T:Event
        {
            eventPublisher.Publish(new EntityInserted<T>(entity));
        }

        public static void EntityInserted<T>(this IEventPublisher eventPublisher, T entity, Dictionary<string, string> fieldValues) where T : Event
        {
            eventPublisher.Publish(new EntityInserted<T>(entity, fieldValues));
        }

        public static void EntityUpdated<T>(this IEventPublisher eventPublisher, T entity) where T : Event
        {
            eventPublisher.Publish(new EntityUpdated<T>(entity));
        }

        public static void EntityUpdated<T>(this IEventPublisher eventPublisher, T entity, T oldEntity, Dictionary<string, string> fieldValues) where T : Event
        {
            eventPublisher.Publish(new EntityUpdated<T>(entity, oldEntity, fieldValues));
        }

        public static void EntityDeleted<T>(this IEventPublisher eventPublisher, T entity) where T : Event
        {
            eventPublisher.Publish(new EntityDeleted<T>(entity));
        }

        public static void EntityGeted<T>(this IEventPublisher eventPublisher, T entity) where T : Event
        {
            eventPublisher.Publish(new EntityGeted<T>(entity));
        }

        public static void EntityChangeStatus<T, TChangeStatus>(this IEventPublisher eventPublisher, T entity, TChangeStatus oldStatus) where T : Event
        {
            eventPublisher.Publish(new EntityChangeStatus<T, TChangeStatus>(entity, oldStatus));
        }

        #endregion

        #region 异步通知
        public static void AsyEntityInserted<T>(this IEventPublisher eventPublisher, T entity) where T : Event
        {
            Action<T> insertBox = m => eventPublisher.Publish(new EntityInserted<T>(entity));
            insertBox.BeginInvoke(entity, null, null);
        }

        public static void AsyEntityInserted<T>(this IEventPublisher eventPublisher, T entity, Dictionary<string, string> fieldValues) where T : Event
        {
            Action<T> insertBox = m => eventPublisher.Publish(new EntityInserted<T>(entity, fieldValues));
            insertBox.BeginInvoke(entity, null, null);
        }


        public static void AsyEntityUpdated<T>(this IEventPublisher eventPublisher, T entity) where T : Event
        {
            Action<T> insertBox = m => eventPublisher.Publish(new EntityUpdated<T>(entity));
            insertBox.BeginInvoke(entity, null, null);
        }

        public static void AsyEntityUpdated<T>(this IEventPublisher eventPublisher, T entity, T oldEntity, Dictionary<string, string> fieldValues) where T : Event
        {
            Action<T> insertBox = m => eventPublisher.Publish(new EntityUpdated<T>(entity, oldEntity, fieldValues));
            insertBox.BeginInvoke(entity, null, null);
        }

        public static void AsyEntityChangeStatus<T, TChangeStatus>(this IEventPublisher eventPublisher, T entity, TChangeStatus oldStatus) where T : Event
        {
            Action<T> insertBox = m => eventPublisher.Publish(new EntityChangeStatus<T, TChangeStatus>(entity, oldStatus));
            insertBox.BeginInvoke(entity, null, null);
        }

        public static void AsyEntityDeleted<T>(this IEventPublisher eventPublisher, T entity) where T : Event
        {
            Action<T> insertBox = m => eventPublisher.Publish(new EntityDeleted<T>(entity));
            insertBox.BeginInvoke(entity, null, null);
        }

        public static void AsyEntityGeted<T>(this IEventPublisher eventPublisher, T entity) where T : Event
        {
            Action<T> insertBox = m => eventPublisher.Publish(new EntityGeted<T>(entity));
            insertBox.BeginInvoke(entity, null, null);
        }

        public static void AsyEntityReported<T>(this IEventPublisher eventPublisher, T entity) where T : Event
        {
            Action<T> insertBox = m => eventPublisher.Publish(new EntityReported<T>(entity));
            insertBox.BeginInvoke(entity, null, null);
        }
        #endregion
    }
}
