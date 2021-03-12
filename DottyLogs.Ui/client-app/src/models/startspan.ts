export default class StartSpan {
    spanIdentifier: string;
    traceIdentifier: string;
    requestUpdateStatus: string;
    threadId: string;
    requestUrl: string;
    parentSpanIdentifier: string;
    hostname: string;
    applicationName: string;

    constructor(spanIdentifier: string, traceIdentifier: string, requestUpdateStatus: string, threadId: string, requestUrl: string, parentSpanIdentifier: string, hostname: string, applicationName: string) {
        this.spanIdentifier = spanIdentifier;
        this.traceIdentifier = traceIdentifier;
        this.requestUpdateStatus = requestUpdateStatus;
        this.threadId = threadId;
        this.requestUrl = requestUrl;
        this.parentSpanIdentifier = parentSpanIdentifier;
        this.hostname = hostname;
        this.applicationName = applicationName;
    }
}