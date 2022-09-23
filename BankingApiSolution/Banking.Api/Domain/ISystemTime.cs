namespace Banking.Api.Domain;

public interface ISystemTime
{
    DateTime GetCurrent();
}