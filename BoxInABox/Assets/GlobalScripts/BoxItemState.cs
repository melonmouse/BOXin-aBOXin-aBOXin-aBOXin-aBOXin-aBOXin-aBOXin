public class BoxItemState {
    // The item that is contained in the box to be transfered into the next minigame
    public Item HeldItem{ get; set; }

    private BoxItemState() {}  
    private static BoxItemState _instance = null;  
    public static BoxItemState Instance {  
        get {  
            if (_instance == null) {  
                _instance = new BoxItemState();  
            }  
            return _instance;  
        }  
    }

    public enum Item {
        // add items
        BaseItem,
    }
}