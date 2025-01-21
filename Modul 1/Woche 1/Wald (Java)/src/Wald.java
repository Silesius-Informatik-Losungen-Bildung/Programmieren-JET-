import java.util.ArrayList;
import java.util.List;

public class Wald {
    private List<Baum> lstBaeume;

    public Wald() {
        lstBaeume = new ArrayList<Baum>();
    }

    public List<Baum> getLstBaeume() {
        return lstBaeume;
    }

    public void setLstBaeume(List<Baum> lstBaeume) {
        this.lstBaeume = lstBaeume;
    }

    public void addBaum(Baum baum) {
        lstBaeume.add(baum);
    }
}

