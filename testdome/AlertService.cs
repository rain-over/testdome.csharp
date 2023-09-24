namespace testdome;

/*
 * Refactor the AlertService and AlsertDAO Classes
 * * Create a new interface, names IAlertDAO, that contains the same methods as AlertDAO.
 * * AlertDAO should implement the IAlertDAO interface.
 * * AlertService should have a public constructor that accepts IalertDAO.
 * * The RaiseAlert and GetAlertTime methods should use the object passed through the constructor.
 */

public class AlertService
{
    private readonly AlertDAO storage = new AlertDAO();
    private IAlertDAO alertDAO;
    public AlertService(IAlertDAO alert)
    {
        alertDAO = alert;
    }
    public Guid RaiseAlert()
    {
        return this.alertDAO.AddAlert(DateTime.Now);
    }

    public DateTime GetAlertTime(Guid id)
    {
        return this.alertDAO.GetAlert(id);
    }
}

public interface IAlertDAO
{
    public Guid AddAlert(DateTime time);
    public DateTime GetAlert(Guid id);
}

public class AlertDAO : IAlertDAO
{
    private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

    public Guid AddAlert(DateTime time)
    {
        Guid id = Guid.NewGuid();
        this.alerts.Add(id, time);
        return id;
    }

    public DateTime GetAlert(Guid id)
    {
        return this.alerts[id];
    }
}


/* 
 * 
 * 
// ---------------------- INITIAL ---------------------- //
using System.Collections.Generic;
using System;


public class AlertService
{
    private readonly AlertDAO storage = new AlertDAO();
    private IAlertDAO alertDAO;
    public AlertService(IAlertDAO alert)
    {
        alertDAO = alert;
    }
    public Guid RaiseAlert()
    {
        return this.alertDAO.AddAlert(DateTime.Now);
    }

    public DateTime GetAlertTime(Guid id)
    {
        return this.alertDAO.GetAlert(id);
    }
}

public interface IAlertDAO
{
    public Guid AddAlert(DateTime time);
    public DateTime GetAlert(Guid id);
}

public class AlertDAO : IAlertDAO
{
    private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

    public Guid AddAlert(DateTime time)
    {
        Guid id = Guid.NewGuid();
        this.alerts.Add(id, time);
        return id;
    }

    public DateTime GetAlert(Guid id)
    {
        return this.alerts[id];
    }
}
*/