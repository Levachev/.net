

static class StrategyFactory {
    public static Strategy createForName(string strategyName){
        switch(strategyName){
            case "simple" :
                return new SimpleStrategy();
            case "random" :
                return new RandomStrategy();
            case "repeat" :
                return new RepeatStrategy();
            case "firstRed" :
                return new MyFirstRedStrategy();
            default :
                return null;
        }
    }
}