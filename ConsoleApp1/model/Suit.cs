
enum Suit {
    hearts,
    diamonds,
    cross,
    spades
}

static class SuitUtil {
    public static Color getColor(Suit suit){
        switch(suit){
            case Suit.cross :
                return Color.black;
            case Suit.spades :
                return Color.black;
            case Suit.hearts :
                return Color.red;
            case Suit.diamonds :
                return Color.red;
            default :
                return Color.red;
        }
    }
}
