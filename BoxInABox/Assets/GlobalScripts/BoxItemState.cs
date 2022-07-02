public class BoxItemState {

    // The item that is contained in the box to be transferred into the next mini game
    public Item HeldItem{ get; set; }

    private BoxItemState() { }  
    
    private static BoxItemState _instance;  
    public static BoxItemState Instance => _instance ??= new BoxItemState();

    public enum Item {
        // add items
        BaseItem,
        Motorcycle,
        Mallet,
        ButterflyCatchingNet,
        HourGlass
    }
}