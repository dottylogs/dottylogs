export default class Span {
    spanIdentifier: string;
    requestUrl: string;
    traceIdentifier: string;
    childSpans: Span[];
    logs: string[];
    inProgress: boolean;
    hostname: string;
    applicationName: string;

    constructor(spanIdentifier: string, requestUrl: string, traceIdentifier: string, hostname: string, applicationName: string) {
        this.spanIdentifier = spanIdentifier;
        this.requestUrl = requestUrl;
        this.traceIdentifier = traceIdentifier;
        this.childSpans = [];
        this.logs = [];
        this.inProgress = true;
        this.hostname = hostname;
        this.applicationName = applicationName;
    }

    get childrenCount(): number {
        let count = 0;
        this.childSpans.forEach(element => {
            count += element.childrenCount + 1;
        });

        return count;
    }
}