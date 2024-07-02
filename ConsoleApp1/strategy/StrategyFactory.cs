

static class StrategyFactory {
    public static ICardPickStrategy createForName(string strategyName){
        switch(strategyName){
            case "random" :
                return new RandomStrategy();
            case "firstRed" :
                return new MyFirstRedStrategy();
            default :
                return null;
        }
    }
}