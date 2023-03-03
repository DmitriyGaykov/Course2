package SaxParser;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

public class SaxParserHandler extends DefaultHandler {
    private static final String CAR_TAG = "car";
    private final String NAME_TAG = "name";
    private final String FILLCONS_TAG = "fillConsumption";
    private final String CARTYPE_TAG = "carType";

    private String currentTag = "";
    @Override
    public void startDocument() throws SAXException {
//        System.out.println("Start document");
    }

    @Override
    public void endDocument() throws SAXException {
//        System.out.println("End document");
    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
//        System.out.println("Start element " + qName);
        currentTag = qName;
    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
//        System.out.println("End element " + qName);
    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        if(currentTag == CAR_TAG)
        {

        }
    }
}
