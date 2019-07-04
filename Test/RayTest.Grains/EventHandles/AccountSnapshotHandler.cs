﻿using Ray.Core.Snapshot;
using RayTest.IGrains.Events;
using RayTest.IGrains.States;

namespace RayTest.Grains.EventHandles
{
    public class AccountSnapshotHandler : SnapshotHandler<long, AccountState>
    {
        public static void AmountTransferEventHandle(AccountState state, AmountTransferEvent evt)
        {
            state.Balance = evt.Balance;
        }
        public static void AmountAddEventHandle(AccountState state, AmountAddEvent evt)
        {
            state.Balance += evt.Amount;
        }
    }
}