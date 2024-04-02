namespace Aweton.Mxw.App;

internal class FloatingPointCopocessor : IFloatingPointCopocessor
{
    public Task<double> Divide(double numerator, double denominator) => Task.FromResult(numerator / denominator);
}
