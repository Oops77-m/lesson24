FROM jenkins/jenkins:2.568.3-jdk21

USER root

# --------------------------------------------------
# Docker CLI
# --------------------------------------------------

RUN apt-get update && \
    apt-get install -y \
        lsb-release \
        ca-certificates \
        curl \
        gnupg \
        wget && \
    install -m 0755 -d /etc/apt/keyrings && \
    curl -fsSL https://download.docker.com/linux/debian/gpg \
        -o /etc/apt/keyrings/docker.asc && \
    chmod a+r /etc/apt/keyrings/docker.asc && \
    echo "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.asc] \
    https://download.docker.com/linux/debian \
    $(. /etc/os-release && echo "$VERSION_CODENAME") stable" \
    | tee /etc/apt/sources.list.d/docker.list > /dev/null && \
    apt-get update && \
    apt-get install -y docker-ce-cli && \
    rm -rf /var/lib/apt/lists/*


# --------------------------------------------------
# Microsoft repository
# --------------------------------------------------

RUN wget https://packages.microsoft.com/config/debian/13/packages-microsoft-prod.deb \
        -O /tmp/packages-microsoft-prod.deb && \
    dpkg -i /tmp/packages-microsoft-prod.deb && \
    rm /tmp/packages-microsoft-prod.deb


# --------------------------------------------------
# .NET 10 SDK
# --------------------------------------------------

RUN apt-get update && \
    apt-get install -y dotnet-sdk-10.0 && \
    rm -rf /var/lib/apt/lists/*


# --------------------------------------------------
# Browsers
# --------------------------------------------------

RUN apt-get update && \
    apt-get install -y firefox-esr chromium chromium-driver && \
    rm -rf /var/lib/apt/lists/*

RUN uname -m && \
    chromium --version && \
    chromedriver --version && \
    which chromium && \
    which chromedriver

# --------------------------------------------------
# Browser environment
# --------------------------------------------------

ENV CHROME_BIN=/usr/bin/chromium
ENV FIREFOX_BIN=/usr/bin/firefox


# --------------------------------------------------
# Verify installation
# --------------------------------------------------

RUN echo "=== .NET ===" && \
    dotnet --version && \
    echo "=== Chromium ===" && \
    chromium --version && \
    echo "=== ChromeDriver ===" && \
    chromedriver --version && \
    echo "=== Firefox ===" && \
    firefox --version


# --------------------------------------------------
# Jenkins user
# --------------------------------------------------

USER jenkins

RUN jenkins-plugin-cli \
    --plugins "blueocean docker-workflow json-path-api"

