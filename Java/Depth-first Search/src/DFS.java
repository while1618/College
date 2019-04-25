public class DFS {
    private Cvor[] listaCvorova;
    private boolean neusmerenGraf;

    public DFS(boolean neusmerenGraf, String[] imenaCvorova, String[] cvorISused) {
        this.neusmerenGraf = neusmerenGraf;
        this.listaCvorova = new Cvor[imenaCvorova.length];

        for(int i = 0; i < imenaCvorova.length; i++)
            this.listaCvorova[i] = new Cvor(imenaCvorova[i], null);

        for(int i = 0; i < cvorISused.length; i++) {
            String[] podeljenString = cvorISused[i].split(";");
            int indexCvora = indexZaIme(podeljenString[0]);
            int indexSuseda = indexZaIme(podeljenString[1]);

            this.listaCvorova[indexCvora].sused = new Sused(indexSuseda, this.listaCvorova[indexCvora].sused);
            System.out.println("provera: " + listaCvorova[indexCvora].sused.getIndexCvora());
            if(this.neusmerenGraf)
                this.listaCvorova[indexSuseda].sused = new Sused(indexCvora, this.listaCvorova[indexSuseda].sused);
        }
    }

    private int indexZaIme(String ime) {
        for (int indexCvora = 0; indexCvora < this.listaCvorova.length; indexCvora++) {
            if (this.listaCvorova[indexCvora].getImeCovra().equals(ime)) {
                return indexCvora;
            }
        }
        return -1;
    }

    private void dfs(int indexCovra, boolean[] posecen) {
        posecen[indexCovra] = true;
        System.out.println("posecuje " + this.listaCvorova[indexCovra].getImeCovra());
        for (Sused sused = this.listaCvorova[indexCovra].sused; sused != null; sused=sused.sledeciSused) {
            if (!posecen[sused.getIndexCvora()]) {
                System.out.println("\n" + this.listaCvorova[indexCovra].getImeCovra() + "--" + this.listaCvorova[sused.getIndexCvora()].getImeCovra());
                dfs(sused.getIndexCvora(), posecen);
            }
        }
    }

    public void dfs() {
        boolean[] posecen = new boolean[this.listaCvorova.length];
        for (int indexCvora = 0; indexCvora < posecen.length; indexCvora++) {
            if (!posecen[indexCvora]) {
                System.out.println("\nPocinje od " + this.listaCvorova[indexCvora].getImeCovra());
                dfs(indexCvora, posecen);
            }
        }
    }
}
