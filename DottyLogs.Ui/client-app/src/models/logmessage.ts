export default class LogMessage {
    spanIdentifier: string;
    message: string;
    timestamp: string;

    constructor(spanIdentifier: string, message: string, timestamp: string) {
        this.spanIdentifier = spanIdentifier;
        this.message = message;
        this.timestamp = timestamp;
    }
}