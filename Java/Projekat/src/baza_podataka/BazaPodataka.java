package baza_podataka;

import java.sql.*;

public class BazaPodataka {
    private Connection connection;
    private static BazaPodataka instanca;

    private BazaPodataka(){
        try{
            Class.forName("org.sqlite.JDBC");
            connection = DriverManager.getConnection("jdbc:sqlite:muzickaBaza.db");
        } catch (Exception e){
            System.err.println(e.getClass().getName() + " : " + e.getMessage());
            System.exit(0);
        }
    }

    public static BazaPodataka getInstanca() {
        if(instanca == null)
            instanca = new BazaPodataka();
        return instanca;
    }

    public void automatskaTransakcija(boolean on_off) throws SQLException {
        connection.setAutoCommit(on_off);
    }

    public void snimiTransakciju() throws SQLException{
        connection.commit();
    }

    public int updateInsertDeletUpit(String upit) throws SQLException{
        Statement statement = connection.createStatement();
        return statement.executeUpdate(upit);
    }

    public ResultSet selectUpit(String upit) throws SQLException{
        Statement statement = connection.createStatement();
        return statement.executeQuery(upit);
    }
}
