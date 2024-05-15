

class Derby {
    private Person person1;
    private Person person2;

    public Derby(Person person1, Person person2){
        this.person1 = person1;
        this.person2 = person2;
    }

    public bool singleExperiment(){
        int person1Move = person1.move();
        int person2Move = person2.move();

        person1.updateStrategy(person1Move);
        person2.updateStrategy(person2Move);

        Card person1Card = person1.getCard(person2Move-1);
        Card person2Card = person2.getCard(person1Move-1);

        //Console.WriteLine("\n"+ilonCard.GetColor());
        //Console.WriteLine(markCard.GetColor()+"\n");

        return person1Card.GetColor() == person2Card.GetColor();
    }
}