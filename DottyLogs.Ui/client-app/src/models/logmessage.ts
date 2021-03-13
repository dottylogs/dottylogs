export default class LogMessage {
    spanIdentifier: string;
    message: string;
    dateTimeUtc: string;

    constructor(spanIdentifier: string, message: string, dateTimeUtc: string) {
        this.spanIdentifier = spanIdentifier;
        this.message = message;
        this.dateTimeUtc = dateTimeUtc;
    }
}