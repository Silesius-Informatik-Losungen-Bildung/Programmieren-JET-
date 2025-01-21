
public class Main {
    public static void main(String[] args) {
        var wald = new Wald();
        var ahorn = new Baum();
        ahorn.setHoehe(12);
        ahorn.setName("Ahorn");
        wald.AddBaum(ahorn);

        var tanne = new Baum();
        tanne.setHoehe(12);
        tanne.setName("Tanne");
        wald.AddBaum(tanne);

        System.out.println("Im Wald gibt es " + wald.getlstBaeume().size() + " Bäume");
    }


}