namespace RajaAgriApp.AppDependencyService
{
    public interface IMediaService
    {
        void SaveImageFromByte(byte[] imageByte, string filename);
    }
}
