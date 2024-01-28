﻿using GitHub.JPMikkers.DHCP;
using System;
using System.ComponentModel;
using System.Net;

namespace ManagedDHCPService;

[Serializable()]
public class ReservationConfiguration
{
    private IPAddress _poolStart = IPAddress.None;
    private IPAddress _poolEnd = IPAddress.None;
    private bool _preempt;

    public string MacTaste
    {
        get;
        set;
    } = string.Empty;

    public string HostName
    {
        get;
        set;
    } = string.Empty;

    public string PoolStart
    {
        get
        {
            return _poolStart.ToString();
        }
        set
        {
            _poolStart = IPAddress.Parse(value);
        }
    }

    public string PoolEnd
    {
        get
        {
            return _poolEnd.ToString();
        }
        set
        {
            _poolEnd = IPAddress.Parse(value);
        }
    }

    [DefaultValue(false)]
    public bool Preempt
    {
        get
        {
            return _preempt;
        }
        set
        {
            _preempt = value;
        }
    }

    public ReservationItem ConstructReservationItem()
    {
        return new ReservationItem()
        {
            HostName = this.HostName,
            MacTaste = this.MacTaste,
            PoolStart = _poolStart,
            PoolEnd = _poolEnd,
            Preempt = _preempt,
        };
    }
}