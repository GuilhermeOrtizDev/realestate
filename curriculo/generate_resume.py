#!/usr/bin/env python3
"""Gera currículo ATS-friendly (1 página, coluna única, texto selecionável)."""

from pathlib import Path

from reportlab.lib.colors import HexColor, black, white
from reportlab.lib.enums import TA_CENTER, TA_JUSTIFY, TA_LEFT
from reportlab.lib.pagesizes import A4
from reportlab.lib.styles import ParagraphStyle, getSampleStyleSheet
from reportlab.lib.units import mm
from reportlab.platypus import (
    HRFlowable,
    KeepTogether,
    Paragraph,
    SimpleDocTemplate,
    Spacer,
)

OUTPUTS = [
    Path("/workspace/curriculo/Guilherme_Ortiz_Curriculo.pdf"),
    Path("/opt/cursor/artifacts/Guilherme_Ortiz_Curriculo.pdf"),
]

INK = HexColor("#1a1a1a")
MUTED = HexColor("#444444")
ACCENT = HexColor("#2c3e50")
RULE = HexColor("#c8c8c8")


def styles():
    base = getSampleStyleSheet()
    return {
        "name": ParagraphStyle(
            "Name",
            parent=base["Normal"],
            fontName="Helvetica-Bold",
            fontSize=18,
            leading=22,
            textColor=INK,
            alignment=TA_CENTER,
            spaceAfter=2,
        ),
        "headline": ParagraphStyle(
            "Headline",
            parent=base["Normal"],
            fontName="Helvetica",
            fontSize=9.5,
            leading=12,
            textColor=ACCENT,
            alignment=TA_CENTER,
            spaceAfter=4,
        ),
        "contact": ParagraphStyle(
            "Contact",
            parent=base["Normal"],
            fontName="Helvetica",
            fontSize=8.5,
            leading=11,
            textColor=MUTED,
            alignment=TA_CENTER,
            spaceAfter=8,
        ),
        "section": ParagraphStyle(
            "Section",
            parent=base["Normal"],
            fontName="Helvetica-Bold",
            fontSize=10,
            leading=13,
            textColor=INK,
            spaceBefore=8,
            spaceAfter=3,
        ),
        "body": ParagraphStyle(
            "Body",
            parent=base["Normal"],
            fontName="Helvetica",
            fontSize=8.7,
            leading=11.2,
            textColor=INK,
            alignment=TA_JUSTIFY,
            spaceAfter=4,
        ),
        "job_title": ParagraphStyle(
            "JobTitle",
            parent=base["Normal"],
            fontName="Helvetica-Bold",
            fontSize=9,
            leading=11.5,
            textColor=INK,
            spaceBefore=5,
            spaceAfter=0,
        ),
        "job_meta": ParagraphStyle(
            "JobMeta",
            parent=base["Normal"],
            fontName="Helvetica-Oblique",
            fontSize=8.2,
            leading=10.5,
            textColor=MUTED,
            spaceAfter=2,
        ),
        "bullet": ParagraphStyle(
            "Bullet",
            parent=base["Normal"],
            fontName="Helvetica",
            fontSize=8.4,
            leading=10.8,
            textColor=INK,
            leftIndent=10,
            firstLineIndent=-8,
            spaceAfter=1.2,
            alignment=TA_LEFT,
        ),
        "skills": ParagraphStyle(
            "Skills",
            parent=base["Normal"],
            fontName="Helvetica",
            fontSize=8.3,
            leading=10.8,
            textColor=INK,
            spaceAfter=1.5,
        ),
    }


def section_rule():
    return HRFlowable(
        width="100%",
        thickness=0.6,
        color=RULE,
        spaceBefore=0,
        spaceAfter=4,
    )


def bullet(text: str, s) -> Paragraph:
    # Hífen ASCII: parsers ATS leem com mais confiabilidade que bullet unicode
    return Paragraph(f"- {text}", s["bullet"])


def build_story(s):
    story = []

    story.append(Paragraph("GUILHERME ORTIZ", s["name"]))
    story.append(
        Paragraph(
            "Especialista Full Cycle | .NET &amp; Angular | Cloud &amp; AI Integration",
            s["headline"],
        )
    )
    story.append(
        Paragraph(
            "Ponta Grossa, PR | (42) 98886-0522 | guiortizsantos12@gmail.com<br/>"
            "LinkedIn: linkedin.com/in/dev-guilherme-ortiz",
            s["contact"],
        )
    )

    story.append(Paragraph("SOBRE", s["section"]))
    story.append(section_rule())
    story.append(
        Paragraph(
            "Desenvolvedor Sênior Full Cycle (.NET, Angular, AWS), com foco em "
            "arquitetura de microsserviços, cloud e qualidade de software. "
            "Participo da definição técnica e da construção end-to-end — da API "
            "à infraestrutura — com autonomia no ciclo de vida do produto.",
            s["body"],
        )
    )

    story.append(Paragraph("EXPERIÊNCIA PROFISSIONAL", s["section"]))
    story.append(section_rule())

    # SmartTravel
    story.append(
        Paragraph(
            "Desenvolvedor Sênior — SmartTravel"
            '&nbsp;&nbsp;<font color="#666666">Jul 2024 – Atual</font>',
            s["job_title"],
        )
    )
    for t in [
        "Participei da migração da infraestrutura para AWS em 3 meses, saindo de Windows para Linux e reduzindo dependência de ambiente legado.",
        "Refatorei o sistema de síncrono para assíncrono para viabilizar a operação em Linux e melhorar resiliência sob carga.",
        "Desenvolvi o motor Conexão para matching de rotas multi-trecho em tempo real (ex.: CWB→SP→Rio) com grafos e DocumentDB, alimentado por worker Kafka.",
        "Conduzi o ciclo com IA (Prompt Engineering, LLM, Semantic Kernel, RAG): análise da base SQL Server de referência, documentação via MCP no Confluence, especificação em Markdown, TDD e geração de código; MCP integrado a AWS, Grafana e GitHub para observabilidade e workflows.",
        "Atuei na arquitetura e evolução de microsserviços críticos de logística, vendas e financeiro.",
    ]:
        story.append(bullet(t, s))

    # Cyber
    story.append(
        Paragraph(
            "Especialista Full Cycle — Cyber Software"
            '&nbsp;&nbsp;<font color="#666666">Fev 2023 – Ago 2024</font>',
            s["job_title"],
        )
    )
    story.append(
        Paragraph(
            "Empresa própria — projetos sob encomenda / PJ",
            s["job_meta"],
        )
    )
    for t in [
        "Concepção e implementação completa da arquitetura de plataforma imobiliária multi-tenant (APIs .NET + UI), com isolamento por cliente.",
        "Entreguei o Te-A App (iOS e Android) em 3 meses, com pagamentos, assinaturas e publicação nas lojas Apple e Google.",
        "Montei DevOps completo na AWS (EC2, RDS, S3, Load Balancer, ElastiCache) com observabilidade, suportando pagamentos e ciclo de assinatura em produção.",
    ]:
        story.append(bullet(t, s))

    # Wake
    story.append(
        Paragraph(
            "Desenvolvedor Pleno — Wake Commerce"
            '&nbsp;&nbsp;<font color="#666666">Jul 2023 – Jun 2024</font>',
            s["job_title"],
        )
    )
    for t in [
        "Desenvolvi o Storefront como centralizador de APIs, substituindo chamadas dispersas a múltiplos serviços por um único ponto de acesso e melhorando performance e velocidade das consultas.",
        "Implementei comunicação GraphQL e geração dinâmica de código frontend com Escriban, acelerando entregas de telas e contratos tipados.",
    ]:
        story.append(bullet(t, s))

    # Meta
    story.append(
        Paragraph(
            "Desenvolvedor Pleno — Meta"
            '&nbsp;&nbsp;<font color="#666666">Jun 2022 – Jun 2023</font>',
            s["job_title"],
        )
    )
    for t in [
        "Atuei na otimização de microsserviços de análise de crédito e scoring de risco, melhorando tempo de resposta e estabilidade sob volume de consultas.",
        "Participei do desenvolvimento Full Stack em fase crítica de projeto de logística de transporte, entregando funcionalidades no caminho crítico do go-live.",
    ]:
        story.append(bullet(t, s))

    # Scheffer
    story.append(
        Paragraph(
            "Desenvolvedor Júnior — Scheffer Logística e Automação"
            '&nbsp;&nbsp;<font color="#666666">Jan 2021 – Mai 2022</font>',
            s["job_title"],
        )
    )
    for t in [
        "Efetivado após 3 meses de estágio pela performance na vaga aberta — primeira posição CLT.",
        "Com 6 meses de casa, propus e coordenei a migração de sistemas Windows Forms para Web (ASP.NET MVC Core); em 1 ano desenhei a arquitetura e conduzi a evolução do legado.",
        "Desenvolvi soluções WCS/WMS para automação logística industrial.",
    ]:
        story.append(bullet(t, s))

    story.append(Paragraph("FORMAÇÃO", s["section"]))
    story.append(section_rule())
    story.append(
        Paragraph(
            "Bacharelado em Ciência da Computação — UTFPR | 2023",
            s["body"],
        )
    )

    story.append(Paragraph("SKILLS", s["section"]))
    story.append(section_rule())
    for line in [
        "<b>Backend &amp; IA:</b> .NET 8, EF Core, Microservices, Prompt Engineering, LLM, RAG, Semantic Kernel",
        "<b>Frontend:</b> Angular, TypeScript, Razor, Bootstrap",
        "<b>Cloud &amp; Infra:</b> AWS (EC2, S3, RDS, Load Balancer, ElastiCache), DigitalOcean, Docker, Kubernetes, CI/CD",
        "<b>Data &amp; Observability:</b> SQL Server, PostgreSQL, DocumentDB, Grafana, CloudWatch, Prometheus",
        "<b>Messaging &amp; APIs:</b> RabbitMQ, Kafka, Hangfire, GraphQL, RESTful",
        "<b>Ferramentas:</b> MCP (Confluence, AWS, Grafana, GitHub), Cursor",
    ]:
        story.append(Paragraph(line, s["skills"]))

    return story


def main():
    s = styles()
    for out in OUTPUTS:
        out.parent.mkdir(parents=True, exist_ok=True)
        doc = SimpleDocTemplate(
            str(out),
            pagesize=A4,
            leftMargin=14 * mm,
            rightMargin=14 * mm,
            topMargin=10 * mm,
            bottomMargin=10 * mm,
            title="Guilherme Ortiz — Currículo",
            author="Guilherme Ortiz",
        )
        doc.build(build_story(s))
        print(f"Wrote {out} ({out.stat().st_size} bytes)")


if __name__ == "__main__":
    main()
