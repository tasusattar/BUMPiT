public class ScreenProperties 
{
    private static float asRat;

    private static float oldWidth;
    private static float oldHeight;

    private static float sizeMultiplier;

    private static float newWidth;

    private static float xMultiplier;
    private static float yMultiplier;
    private static float xDiff;
    private static float yDiff;



    public static void SetAllScreenProps(float aspected){
        asRat = aspected;

        oldWidth = 2.25f;
        oldHeight = 5f;
        sizeMultiplier = (20f/9f)*asRat;
        newWidth = 5 * asRat * sizeMultiplier;
        xMultiplier = newWidth/oldWidth;
        yMultiplier = (5*sizeMultiplier)/oldHeight;

        xDiff = newWidth-oldWidth;
        yDiff = (5*sizeMultiplier)-oldHeight;

    }

    public static float GetAspectRatio(){return asRat;}

    public static float GetSizeMult(){return sizeMultiplier;}
    public static float GetXMult(){return xMultiplier;}
    public static float GetYMult(){return yMultiplier;}
    public static float GetXDiff(){return xDiff;}
    public static float GetYDiff(){return yDiff;}

    


}
