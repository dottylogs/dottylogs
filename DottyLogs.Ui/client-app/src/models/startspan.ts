export default class StartSpan {
    spanIdentifier: string;
    tracingIdentifier: string;
    requestUpdateStatus: string;
    threadId: string;
    requestUrl: string;
    parentSpanIdentifier: string;
    hostname: string;
    applicationName: string;

    constructor(spanIdentifier: string, tracingIdentifier: string, requestUpdateStatus: string, threadId: string, requestUrl: string, parentSpanIdentifier: string, hostname: string, applicationName: string) {
        this.spanIdentifier = spanIdentifier;
        this.tracingIdentifier = tracingIdentifier;
        this.requestUpdateStatus = requestUpdateStatus;
        this.threadId = threadId;
        this.requestUrl = requestUrl;
        this.parentSpanIdentifier = parentSpanIdentifier;
        this.hostname = hostname;
        this.applicationName = applicationName;
    }
}