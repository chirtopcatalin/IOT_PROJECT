#include <ESP8266WiFi.h>
#include <MFRC522.h>
#include <SPI.h>
#include <ArduinoJson.h>

// WiFi & API Settings
const char* ssid = "Addsgshjsks";
const char* password = "unity2025";
const char* serverUrl = "http://127.0.0.1:5275/api/collection/add";

#define SS_PIN 4
#define RST_PIN 5
MFRC522 mfrc522(SS_PIN, RST_PIN);

// WiFi Client
WiFiClient client;

void setup() {
    Serial.begin(115200);
    SPI.begin()
    mfrc522.PCD_Init();
    
    WiFi.begin(ssid, password);
    Serial.print("Connecting to WiFi");
    while (WiFi.status() != WL_CONNECTED) {
        delay(1000);
        Serial.print(".");
    }
    Serial.println("\nWiFi Connected!");
}

void loop() {
    if (!mfrc522.PICC_IsNewCardPresent() || !mfrc522.PICC_ReadCardSerial()) {
        return;
    }

    String binId = "";
    for (byte i = 0; i < mfrc522.uid.size; i++) {
        binId += String(mfrc522.uid.uidByte[i], HEX);
    }
    binId.toUpperCase();
    Serial.println("Scanned RFID: " + binId);

    String timestamp = getFormattedTime();

    sendCollectionData(binId, timestamp);

    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
    
    delay(5000);
}

void sendCollectionData(String binId, String timestamp) {
    WiFiClient client;
    if (client.connect(serverUrl, 80)) {
        Serial.println("Connected to API...");

        StaticJsonDocument<200> jsonDoc;
        jsonDoc["Bin_id"] = binId.toInt();
        jsonDoc["Collection_time"] = timestamp;

        String jsonData;
        serializeJson(jsonDoc, jsonData);

        client.println("POST /api/collection/add HTTP/1.1");
        client.println("Host: " + String(serverUrl));
        client.println("Content-Type: application/json");
        client.print("Content-Length: ");
        client.println(jsonData.length());
        client.println();
        client.println(jsonData);

        Serial.println("Data sent: " + jsonData);
        
        while (client.available()) {
            String response = client.readString();
            Serial.println("Response: " + response);
        }

        client.stop();
    } else {
        Serial.println("Connection to API failed.");
    }
}

String getFormattedTime() {
    timeClient.update();

    String formattedTime = timeClient.getFormattedTime();

    // Format ISO 8601
    int hour = timeClient.getHours();
    int minute = timeClient.getMinutes();
    int second = timeClient.getSeconds();
    int day = timeClient.getDay();
    int month = timeClient.getMonth();
    int year = timeClient.getYear();

    String timestamp = String(year) + "-" +
                       (month < 10 ? "0" + String(month) : String(month)) + "-" +
                       (day < 10 ? "0" + String(day) : String(day)) + "T" +
                       (hour < 10 ? "0" + String(hour) : String(hour)) + ":" +
                       (minute < 10 ? "0" + String(minute) : String(minute)) + ":" +
                       (second < 10 ? "0" + String(second) : String(second));

    return timestamp;
}
